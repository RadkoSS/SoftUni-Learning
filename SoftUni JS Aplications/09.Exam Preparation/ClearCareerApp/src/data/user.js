import * as api from './api.js';
import { clearUserData, getUserData, setUserData } from '../utils/util.js';

const endPoints = {
    login: 'users/login',
    register: 'users/register',
    logout: 'users/logout'
}

async function userLogin(email, password) {
    const userData = await api.post(endPoints.login, { email, password });

    setUserData(userData);
}

async function userRegister(email, password) {
    const userData = await api.post(endPoints.register, { email, password });

    setUserData(userData);
}

async function userLogout() {
    await api.get(endPoints.logout);

    clearUserData();
}

function checkLoggedStatus() {
    if (getUserData() != null) {
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