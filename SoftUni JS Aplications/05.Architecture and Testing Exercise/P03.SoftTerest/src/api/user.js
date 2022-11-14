import * as api from './api.js';

const endPoints = {
    login: 'users/login',
    register: 'users/register',
    logout: 'users/logout'
}

async function userLogin(email, password) {
    const userData = await api.post(endPoints.login, { email, password });

    sessionStorage.setItem('userData', JSON.stringify(userData));
}

async function userRegister(email, password) {
    const userData = await api.post(endPoints.register, { email, password });

    sessionStorage.setItem('userData', JSON.stringify(userData));
}

async function userLogout() {
    await api.get(endPoints.logout);

    sessionStorage.removeItem('userData');
}

function checkLoggedStatus(){
    if(sessionStorage.getItem('userData')){
        return true;
    }
    return false;
}

export {
    userLogin,
    userRegister,
    userLogout,
    checkLoggedStatus
}