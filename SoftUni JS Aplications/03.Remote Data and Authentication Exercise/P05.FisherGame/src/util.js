export function findElement(selector){
    let elementToFind = document.getElementById(selector);
    
    if(!elementToFind){
        elementToFind = document.querySelector(selector);
    }
    return elementToFind;
}

export function findElements(selector){
    let elementsToFind = document.getElementsById(selector);
    
    if(!elementsToFind){
        elementsToFind = document.querySelectorAll(selector);
    }
    return elementsToFind;
}