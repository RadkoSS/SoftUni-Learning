// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const btn = document.getElementById('toggle');
const containerToToggle = document.getElementById('container');

btn.addEventListener('click', toggleVisibility);

function toggleVisibility() {
    const currentState = containerToToggle.style.display;
    containerToToggle.style.display = currentState == 'none' ? 'block' : 'none';
}