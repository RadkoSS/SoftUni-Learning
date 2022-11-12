const domain = 'http://localhost:3030';

async function request(method, url, token, bodyInfo) {
    const information = {
        method,
        headers: {}
    }

    if (token) {
        information.headers["Content-Type"] = "application/json";
        information.headers["X-Authorization"] = token;
    }
    if (bodyInfo) {
        information.body = JSON.stringify(bodyInfo);
    }

    const request = await fetch(`${domain}${url}`, information);

    if(!request.ok){
        const error = await request.json();
        throw new Error(error.message);
    }

    return await request.json();
}

export const get = request.bind(null, 'get');
export const post = request.bind(null, 'post');
export const put = request.bind(null, 'put');
export const deleteReq = request.bind(null, 'delete');