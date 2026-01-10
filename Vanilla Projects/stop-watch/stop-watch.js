let startTime = 0;
let elapsedTime = 0;
let timerId = null;

const display = document.getElementById("display");
const startBtn = document.getElementById("startBtn");
const stopBtn = document.getElementById("stopBtn");
const resetBtn = document.getElementById("resetBtn");

function formatTime(ms) {
    const milliseconds = Math.floor((ms % 1000) / 10);
    const seconds = Math.floor((ms / 1000) % 60);
    const minutes = Math.floor((ms / (1000 * 60)) % 60);
    const hours = Math.floor((ms / (1000 * 60 * 60)));

    let time = "";
    
    if (hours > 0) {
        time += `${String(hours).padStart(2, "0")}:`;
    }

    time += `${String(minutes).padStart(2, "0")}:`;
    time += `${String(seconds).padStart(2, "0")}`;

    if (ms >= 1000) {
        time += `.${String(milliseconds).padStart(2, "0")}`;
    }

    return time;
}

function updateDisplay() {
    elapsedTime = Date.now() - startTime;
    display.textContent = formatTime(elapsedTime);
}

startBtn.addEventListener("click", () => {
    startTime = Date.now() - elapsedTime;
    timerId = setInterval(updateDisplay, 10);

    startBtn.classList.add("hidden");
    stopBtn.classList.remove("hidden");
    resetBtn.classList.remove("hidden");
});

stopBtn.addEventListener("click", () => {
  clearInterval(timerId);
  timerId = null;

  startBtn.textContent = "Start";
  startBtn.classList.remove("hidden");
  stopBtn.classList.add("hidden");
});

resetBtn.addEventListener("click", () => {
  clearInterval(timerId);
  timerId = null;
  elapsedTime = 0;

  display.textContent = "00:00:00";
  startBtn.textContent = "Start";

  startBtn.classList.remove("hidden");
  stopBtn.classList.add("hidden");
  resetBtn.classList.add("hidden");
});

