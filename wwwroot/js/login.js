document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('loginForm');
    const loginBtn = document.getElementById('loginBtn');
    const loginSpinner = document.getElementById('loginSpinner');
    const loginBtnText = document.getElementById('loginBtnText');

    if (loginForm) {
        loginForm.addEventListener('submit', function (e) {
            // Check HTML5 validation and jQuery unobtrusive validation if present
            if (loginForm.checkValidity() && $(loginForm).valid()) {
                // Show loading state
                loginBtn.disabled = true;
                loginSpinner.classList.remove('d-none');
                loginBtnText.textContent = ' Procesando...';
            }
        });
    }

    const togglePassword = document.getElementById('togglePassword');
    const passwordInput = document.getElementById('passwordInput');
    const eyeOpen = document.getElementById('eyeOpen');
    const eyeClosed = document.getElementById('eyeClosed');

    if (togglePassword && passwordInput) {
        togglePassword.addEventListener('click', function () {
            const isPassword = passwordInput.type === 'password';
            passwordInput.type = isPassword ? 'text' : 'password';
            eyeOpen.style.display = isPassword ? 'none' : 'block';
            eyeClosed.style.display = isPassword ? 'block' : 'none';
        });
    }

    const sessionExpiredAlert = document.getElementById('sessionExpiredAlert');
    if (sessionExpiredAlert) {
        setTimeout(function () {
            sessionExpiredAlert.classList.add('fade-out');
            setTimeout(function () {
                sessionExpiredAlert.remove();
            }, 400);
        }, 5000);
    }
});
