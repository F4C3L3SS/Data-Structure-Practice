const icons = document.querySelectorAll(".accordion-icon");

icons.forEach(icon => {
    icon.addEventListener("click", () => {
        const header = icon.closest(".accordion-header");
        const panel = header.nextElementSibling;

        header.classList.toggle("active");

        panel.classList.toggle("hidden");
    })
})