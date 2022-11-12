import { findElement } from "./util.js";

const nav = findElement(`nav`);
nav.addEventListener(`click`, toggle);
debugger
export function toggle(event){
    if(event.target !== `A`){
        return;
    }

    //TO DO

    // if(event.target.classList.includes(`active`)){
    //     event.target.classList.remove(`active`);
    // } else{
    //     event.target.setAttribute(`class`, `active`);
    // }
}