const images = [
    {
        src: 'https://picsum.photos/id/600/600/400',
        alt: 'Forest',
    },
    {
        src: 'https://picsum.photos/id/100/600/400',
        alt: 'Beach',
    },
    {
        src: 'https://picsum.photos/id/200/600/400',
        alt: 'Yak',
    },
    {
        src: 'https://picsum.photos/id/300/600/400',
        alt: 'Hay',
    },
    {
        src: 'https://picsum.photos/id/400/600/400',
        alt: 'Plants',
    },
    {
        src: 'https://picsum.photos/id/500/600/400',
        alt: 'Building',
    },
];

let currentIndex = 0;

const img = document.getElementById('carousel-image');
const leftBtn = document.querySelector('.nav.left');
const rightBtn = document.querySelector('.nav.right');
const dotsContainer = document.querySelector('.dots');

function showImage(index) {
    // ensures overflow and underflow conditions 6 % 6 === 0, 7 % 6 === 1
    currentIndex = (index + images.length) % images.length;

    img.src = images[currentIndex].src;
    img.alt = images[currentIndex].alt;

    updateDots();
}

// optimization to load the images on load, as clicking next attaches the src attributes, 
// which causes the image to download at that time and UI feels laggy
function preloadImages() {
    images.forEach((image) => {
        const src = image.src;
        const img = new Image();
        img.src = src;
    });
} 

/**
 * Updates the visual state of carousel indicator dots.
 * Toggles the 'active' class on each dot to highlight the dot
 * corresponding to the currently displayed carousel item.
 * 
 * @function updateDots
 * @returns {void}
 */
function updateDots() {
    const dots = dotsContainer.children;
    for (let i = 0; i < dots.length; i++) {
        dots[i].classList.toggle('active', i === currentIndex);
    }
}

function createDots() {
    images.forEach((img, index) => {
        const dot = document.createElement('button');
        dot.addEventListener('click', () => showImage(index));
        dotsContainer.appendChild(dot);
    });
}

leftBtn.addEventListener('click', () => showImage(currentIndex - 1));
rightBtn.addEventListener('click', () => showImage(currentIndex + 1));

preloadImages(images);
createDots();
showImage(0);

