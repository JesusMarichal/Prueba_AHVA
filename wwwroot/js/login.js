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
});
