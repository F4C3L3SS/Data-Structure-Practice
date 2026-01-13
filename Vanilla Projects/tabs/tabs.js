// const tabHTML = document.getElementById('tab-html');
// const tabCSS = document.getElementById('tab-css');
// const tabJS = document.getElementById('tab-js');

// tabHTML.addEventListener('click', () => {
//     if (!tabHTML.classList.contains('active')) {
//         tabHTML.classList.add("active");
//         tabCSS.classList.remove('active');
//         tabJS.classList.remove('active');
//     }
// });

// tabCSS.addEventListener('click', () => {
//     if (!tabCSS.classList.contains('active')) {
//         tabCSS.classList.add("active");
//         tabHTML.classList.remove('active');
//         tabJS.classList.remove('active');
//     }
// });

// tabJS.addEventListener('click', () => {
//     if (!tabJS.classList.contains('active')) {
//         tabJS.classList.add("active");
//         tabCSS.classList.remove('active');
//         tabHTML.classList.remove('active');
//     }
// });


// refactored version
/**
 * Selects all DOM elements whose id attribute starts with "tab-"
 * @type {NodeListOf<Element>}
 * @description Uses CSS attribute selector to query all elements with ids beginning with "tab-"
 * This is commonly used to target multiple tab elements in a tabbed interface component
 */
const tabs = document.querySelectorAll('[id^="tab-"]');

tabs.forEach(tab => {
    tab.addEventListener('click', () => {
        const contentId = tab.id.replace('tab-', '');
        const content = document.getElementById(contentId);
        
        // Remove active from all tabs and hide all content
        tabs.forEach(t => t.classList.remove('active'));
        document.querySelectorAll('p[id]').forEach(p => p.classList.add('hidden'));
        
        // Add active to clicked tab and show matching content
        tab.classList.add('active');
        content.classList.remove('hidden');
    });
});

const tabContent = document.querySelectorAll('[p]')
