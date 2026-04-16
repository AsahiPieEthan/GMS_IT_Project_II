(function () {
  const API_LOGIN = "https://localhost:7132/api/member/login";

  function parseDate(str) {
    if (!str) return new Date();
    const [d, m, y] = str.split("/");
    return new Date(`${y}-${m}-${d}`);
  }

  // ── Generate unique QR number from MID ──────────────────────────────────────
  // Format: GYM-{MID padded to 4 digits}-{random seed from MID}-{expiry month+year}
  function generateGymCode(mid, validUntil) {
    const padded   = String(mid).padStart(4, "0");
    const seed     = String(parseInt(mid) * 7391).slice(-4); // deterministic "random"
    const expParts = (validUntil || "").split("/");           // dd/mm/yyyy
    const expCode  = expParts.length === 3
      ? expParts[1] + expParts[2].slice(2)                   // e.g. "0526"
      : "0000";
    return `GYM${padded}${seed}${expCode}`;                  // e.g. GYM00071934052026
  }

  // ── Render CTA ──────────────────────────────────────────────────────────────
  function renderCTA() {
    const gymUser = JSON.parse(localStorage.getItem("gymUser") || "null");
    const ctaArea = document.getElementById("ctaArea");
    if (!ctaArea) return;

    if (gymUser && gymUser.fname) {
      const initials = ((gymUser.fname?.[0] || "") + (gymUser.lname?.[0] || "")).toUpperCase() || "G";
      const fullName = `${gymUser.fname || ""} ${gymUser.lname || ""}`.trim();
      const gymCode  = generateGymCode(gymUser.mid || "0", gymUser.validUntil || "");

      let fillPct = 100;
      if (gymUser.joinDate && gymUser.validUntil) {
        const join    = parseDate(gymUser.joinDate);
        const expiry  = parseDate(gymUser.validUntil);
        const now     = new Date();
        const total   = expiry - join;
        const elapsed = now - join;
        fillPct = Math.max(0, Math.min(100, 100 - (elapsed / total * 100)));
      }

      ctaArea.innerHTML = `
        <div class="profile-wrapper">
          <button class="profile-btn" id="profileToggle">
            <div class="profile-avatar">${initials}</div>
            ${gymUser.fname || "Member"}
          </button>

          <div class="profile-dropdown" id="profileDropdown">

            <div class="pd-header">
              <div class="pd-avatar">${initials}</div>
              <div class="pd-name">${fullName}</div>
              <div class="pd-username">@${gymUser.username || "—"}</div>
            </div>

            <div class="pd-body">
              <div class="pd-row">
                <span class="pd-row-label"><i class="fas fa-envelope"></i> Email</span>
                <span class="pd-row-value">${gymUser.email || "—"}</span>
              </div>
              <div class="pd-row">
                <span class="pd-row-label"><i class="fas fa-id-badge"></i> Member ID</span>
                <span class="pd-row-value">#${gymUser.mid || "—"}</span>
              </div>
              <div class="pd-row">
                <span class="pd-row-label"><i class="fas fa-dumbbell"></i> Plan</span>
                <span class="pd-row-value red">${gymUser.planName || "—"}</span>
              </div>
              <div class="pd-row">
                <span class="pd-row-label"><i class="fas fa-calendar-plus"></i> Joined</span>
                <span class="pd-row-value">${gymUser.joinDate || "—"}</span>
              </div>
              <div class="pd-row">
                <span class="pd-row-label"><i class="fas fa-calendar-times"></i> Expires</span>
                <span class="pd-row-value red">${gymUser.validUntil || "—"}</span>
              </div>
            </div>

            <!-- Validity bar -->
            <div class="validity-bar-wrap">
              <div class="validity-label">
                <span>Membership validity</span>
                <span>${Math.round(fillPct)}% remaining</span>
              </div>
              <div class="validity-bar">
                <div class="validity-fill" id="validityFill" style="width:0%"></div>
              </div>
            </div>

            <!-- QR Code section -->
            <div class="pd-qr-wrap">
              <button class="qr-toggle-btn" id="qrToggleBtn">
                <i class="fas fa-qrcode"></i> Show Gym Pass QR
              </button>
              <div class="qr-box" id="qrBox" style="display:none;">
                <div class="qr-label">SCAN TO ENTER</div>
                <div id="qrCodeImg"></div>
                <div class="qr-code-number">${gymCode}</div>
                <div class="qr-expiry">Valid until: <strong>${gymUser.validUntil || "—"}</strong></div>
              </div>
            </div>

           <div class="pd-footer">
              <button class="edit-profile-btn" id="editProfileBtn">
                <i class="fas fa-user-edit"></i> EDIT PROFILE
              </button>
              <button class="logout-btn" id="logoutBtn">
                <i class="fas fa-sign-out-alt"></i> LOG OUT
              </button>
            </div>

          </div>
        </div>`;

      // Animate validity bar
      setTimeout(() => {
        const fill = document.getElementById("validityFill");
        if (fill) fill.style.width = fillPct + "%";
      }, 300);

      // Toggle profile dropdown
      document.getElementById("profileToggle").addEventListener("click", function (e) {
        e.stopPropagation();
        document.getElementById("profileDropdown").classList.toggle("open");
      });

      // Toggle QR box
      document.getElementById("qrToggleBtn").addEventListener("click", function (e) {
        e.stopPropagation();
        const qrBox = document.getElementById("qrBox");
        const isHidden = qrBox.style.display === "none";

        if (isHidden) {
          qrBox.style.display = "block";
          this.innerHTML = '<i class="fas fa-qrcode"></i> Hide Gym Pass QR';

          // Generate QR using free QR API
          const qrContainer = document.getElementById("qrCodeImg");
          qrContainer.innerHTML = `
            <img
              src="https://api.qrserver.com/v1/create-qr-code/?size=160x160&data=${encodeURIComponent(gymCode)}&bgcolor=111111&color=e63946&qzone=1"
              alt="Gym Pass QR"
              style="width:160px; height:160px; border-radius:8px; display:block; margin:0 auto;"
            >`;
        } else {
          qrBox.style.display = "none";
          this.innerHTML = '<i class="fas fa-qrcode"></i> Show Gym Pass QR';
        }
      });

      // Logout
      document.getElementById("logoutBtn").addEventListener("click", function () {
        localStorage.removeItem("gymUser");
        destroyModal();
        renderCTA();
      });

      // Edit Profile
      document.getElementById("editProfileBtn").addEventListener("click", function (e) {
        e.stopPropagation();
        document.getElementById("profileDropdown").classList.remove("open");
        openEditModal();
      });


      // Close dropdown on outside click
      document.addEventListener("click", function (e) {
        const dd = document.getElementById("profileDropdown");
        if (dd && !e.target.closest(".profile-wrapper")) dd.classList.remove("open");
      });

    } else {
      // LOGGED OUT
      ctaArea.innerHTML = `<button class="cta" id="joinNowBtn">Join Now</button>`;
      document.getElementById("joinNowBtn").addEventListener("click", function (e) {
        e.preventDefault();
        openAuthModal();
      });
    }
  }

  // ── Destroy modal ───────────────────────────────────────────────────────────
  function destroyModal() {
    const old = document.getElementById("gymAuthModal");
    if (old) old.remove();
  }

  // ── Open login modal (always fresh) ─────────────────────────────────────────
  function openAuthModal() {
    destroyModal();

    const modal = document.createElement("div");
    modal.className = "modal open";
    modal.id = "gymAuthModal";
    modal.innerHTML = `
      <div class="modal-content">
        <span class="close-btn" id="gymCloseModal">&times;</span>
        <h2>Sign In To Proceed</h2>
        <form class="auth-form" id="gymLoginForm" autocomplete="off">
          <input type="text"     id="loginUsername" placeholder="Username" required autocomplete="off">
          <input type="password" id="loginPassword" placeholder="Password" required autocomplete="off">
          <a href="#" class="forgot">Forgot your details?</a>
          <p class="login-error" id="loginError"></p>
          <button type="submit" class="auth-btn" id="loginSubmitBtn">
            Sign In <i class="fas fa-sign-in-alt"></i>
          </button>
        </form>
        <hr class="divider">
        <p class="no-account">Don't have an account?</p>
        <button class="signup-outline" id="gymSignupBtn">Sign Up</button>
      </div>`;

    document.body.appendChild(modal);

    document.getElementById("gymCloseModal").addEventListener("click", destroyModal);
    modal.addEventListener("click", function (e) {
      if (e.target === modal) destroyModal();
    });

    document.getElementById("gymSignupBtn").addEventListener("click", function () {
      destroyModal();
      window.location.href = "Membership.html#join";
    });

    document.getElementById("gymLoginForm").addEventListener("submit", async function (e) {
      e.preventDefault();

      const username  = document.getElementById("loginUsername").value.trim();
      const password  = document.getElementById("loginPassword").value;
      const errorEl   = document.getElementById("loginError");
      const submitBtn = document.getElementById("loginSubmitBtn");

      errorEl.textContent   = "";
      errorEl.style.display = "none";
      submitBtn.disabled    = true;
      submitBtn.innerHTML   = 'Signing in... <i class="fas fa-spinner fa-spin"></i>';

      try {
        const response = await fetch(API_LOGIN, {
          method:  "POST",
          headers: { "Content-Type": "application/json" },
          body:    JSON.stringify({ username, password })
        });

        const result = await response.json();

        if (response.ok) {
          localStorage.setItem("gymUser", JSON.stringify({
            username,
            fname:      result.fname      || "",
            lname:      result.lname      || "",
            email:      result.email      || "",
            mid:        result.mid        || "",
            planName:   result.planName   || "—",
            joinDate:   result.joinDate   || "—",
            validUntil: result.validUntil || "—"
          }));
          destroyModal();
          renderCTA();

        } else {
          errorEl.textContent   = result.message || "Invalid username or password.";
          errorEl.style.display = "block";
          submitBtn.disabled    = false;
          submitBtn.innerHTML   = 'Sign In <i class="fas fa-sign-in-alt"></i>';
        }

      } catch (err) {
        errorEl.textContent   = "Cannot connect to server. Make sure API is running.";
        errorEl.style.display = "block";
        submitBtn.disabled    = false;
        submitBtn.innerHTML   = 'Sign In <i class="fas fa-sign-in-alt"></i>';
      }
    });
  }
   
  // ── Edit Profile Modal ──────────────────────────────────────────────────
function openEditModal() {
    const gymUser = JSON.parse(localStorage.getItem("gymUser") || "null");
    if (!gymUser) return;

    const existing = document.getElementById("gymEditModal");
    if (existing) existing.remove();

    const modal = document.createElement("div");
    modal.className = "modal open";
    modal.id = "gymEditModal";
    modal.innerHTML = `
      <div class="modal-content edit-modal-content">
        <span class="close-btn" id="editCloseBtn">&times;</span>
        <h2>Edit Profile</h2>
        <p class="contact-sub">Leave a field blank to keep it unchanged.</p>
        <form class="auth-form" id="editProfileForm" autocomplete="off">

          <label class="edit-label">First Name</label>
          <input type="text" id="editFname" placeholder="${gymUser.fname || ''}" value="${gymUser.fname || ''}">

          <label class="edit-label">Last Name</label>
          <input type="text" id="editLname" placeholder="${gymUser.lname || ''}" value="${gymUser.lname || ''}">

          <label class="edit-label">Email</label>
          <input type="email" id="editEmail" placeholder="${gymUser.email || ''}" value="${gymUser.email || ''}">

          <label class="edit-label">Phone / Mobile</label>
          <input type="text" id="editMobile" placeholder="Enter new mobile number">

          <label class="edit-label">Address</label>
          <input type="text" id="editAddress" placeholder="Enter new address">

          <hr class="divider">
          <p class="edit-pass-title">Change Password <span style="font-size:12px;color:#aaa;">(optional)</span></p>

          <label class="edit-label">Current Password</label>
          <input type="password" id="editOldPass" placeholder="Required to change password">

          <label class="edit-label">New Password</label>
          <input type="password" id="editNewPass" placeholder="Leave blank to keep current">

          <p class="login-error" id="editError"></p>
          <p class="edit-success" id="editSuccess"></p>

          <button type="submit" class="auth-btn" id="editSubmitBtn">
            Save Changes <i class="fas fa-save"></i>
          </button>
        </form>
      </div>`;

    document.body.appendChild(modal);

    document.getElementById("editCloseBtn").addEventListener("click", () => modal.remove());
    modal.addEventListener("click", e => { if (e.target === modal) modal.remove(); });

    document.getElementById("editProfileForm").addEventListener("submit", async function(e) {
        e.preventDefault();

        const errorEl   = document.getElementById("editError");
        const successEl = document.getElementById("editSuccess");
        const submitBtn = document.getElementById("editSubmitBtn");

        errorEl.textContent   = "";
        errorEl.style.display = "none";
        successEl.style.display = "none";
        submitBtn.disabled    = true;
        submitBtn.innerHTML   = 'Saving... <i class="fas fa-spinner fa-spin"></i>';

        const payload = {
            mid:         parseInt(gymUser.mid),
            fname:       document.getElementById("editFname").value.trim(),
            lname:       document.getElementById("editLname").value.trim(),
            email:       document.getElementById("editEmail").value.trim(),
            mobile:      document.getElementById("editMobile").value.trim(),
            address:     document.getElementById("editAddress").value.trim(),
            oldPassword: document.getElementById("editOldPass").value,
            newPassword: document.getElementById("editNewPass").value
        };

        try {
            const res  = await fetch("https://localhost:7132/api/member/update", {
                method:  "PUT",
                headers: { "Content-Type": "application/json" },
                body:    JSON.stringify(payload)
            });
            const data = await res.json();

            if (res.ok) {
                // Update localStorage with new data
                const updated = {
                    ...gymUser,
                    fname:      data.fname      || gymUser.fname,
                    lname:      data.lname      || gymUser.lname,
                    email:      data.email      || gymUser.email,
                    planName:   data.planName   || gymUser.planName,
                    joinDate:   data.joinDate   || gymUser.joinDate,
                    validUntil: data.validUntil || gymUser.validUntil
                };
                localStorage.setItem("gymUser", JSON.stringify(updated));

                successEl.textContent   = "Profile updated successfully!";
                successEl.style.display = "block";
                submitBtn.disabled      = false;
                submitBtn.innerHTML     = 'Save Changes <i class="fas fa-save"></i>';

                // Refresh the profile dropdown after 1.5s
                setTimeout(() => {
                    modal.remove();
                    renderCTA();
                }, 1500);

            } else {
                errorEl.textContent   = data.message || "Update failed.";
                errorEl.style.display = "block";
                submitBtn.disabled    = false;
                submitBtn.innerHTML   = 'Save Changes <i class="fas fa-save"></i>';
            }
        } catch (err) {
            errorEl.textContent   = "Cannot connect to server.";
            errorEl.style.display = "block";
            submitBtn.disabled    = false;
            submitBtn.innerHTML   = 'Save Changes <i class="fas fa-save"></i>';
        }
    });
}
  renderCTA();
})();