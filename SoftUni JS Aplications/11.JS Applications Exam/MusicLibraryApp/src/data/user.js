import * as api from './api.js';
import { clearUserData, setUserData } from '../utils/util.js';

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

function userLogout() {
    api.get(endPoints.logout);

    clearUserData();
}

export {
    userLogin,
    userRegister,
    userLogout,
}