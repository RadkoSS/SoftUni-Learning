export function getFormData(callback) {
    return (event) => {
        event.preventDefault();
        const form = event.target;
        callback(Object.fromEntries(new FormData(form)), form);
    }
}

export function getUserData() {
    const userData = sessionStorage.getItem('user');

    if (userData) {
        return JSON.parse(userData);
    }
    return null;
}

export function setUserData(data) {
    sessionStorage.setItem('user', JSON.stringify(
        {
            email: data.email,
            _id: data._id,
            accessToken: data.accessToken
        }));
}

export function clearUserData() {
    sessionStorage.removeItem('user');
}