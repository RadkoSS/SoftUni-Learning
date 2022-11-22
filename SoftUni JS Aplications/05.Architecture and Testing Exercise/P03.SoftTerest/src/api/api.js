const domain = 'http://localhost:3030/';

async function requester(method, endPoints, data) {
    const options = {
        method,
        headers: {}
    }

    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData) {
        options.headers['Content-Type'] = 'application/json';
        options.headers['X-Authorization'] = userData.accessToken;
    }
    if (data) {
        options.body = JSON.stringify(data);
    }

    try {
        const request = await fetch(domain + endPoints, options);

        if (!request.ok) {
            if(request.status === 403){
                sessionStorage.removeItem('userData');
            }
            const error = await request.json();
            throw new Error(error.message);
        }

        if (request.status === 204) {
            return request;
        } else {
            return await request.json();
        }

    } catch (error) {
        alert(error.message);
        throw error;
    }
}

const get = requester.bind(null, 'get');
const post = requester.bind(null, 'post');
const put = requester.bind(null, 'put');
const patch = requester.bind(null, 'patch');
const deleteReq = requester.bind(null, 'delete');

export {
    get,
    post,
    put,
    patch,
    deleteReq as delete
}