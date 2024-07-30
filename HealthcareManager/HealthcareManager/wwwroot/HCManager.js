let timeout;
const timeoutDuration = 300000; // Timeout duration in milliseconds (e.g., 5 minutes)

function resetTimeout(dotNetHelper) {
    clearTimeout(timeout);
    timeout = setTimeout(() => {
        dotNetHelper.invokeMethodAsync('UserInactive');
    }, timeoutDuration);
}

document.addEventListener('mousemove', () => resetTimeout(dotNetHelper));
document.addEventListener('keydown', () => resetTimeout(dotNetHelper));

window.setDotNetHelper = (dotNetHelper) => {
    resetTimeout(dotNetHelper);
    window.addEventListener('beforeunload', (event) => {
        dotNetHelper.invokeMethodAsync('OnAppClose');
    });
};
