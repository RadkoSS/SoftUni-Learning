import * as api from './api.js'

const endPoints = {
    getAllShoes: 'data/shoes?sortBy=_createdOn%20desc',
    addShoes: 'data/shoes'
}

export async function allShoesData() {
    const response = await api.get(endPoints.getAllShoes);

    return response;
}

export async function addShoes(data) {
    const response = await api.post(endPoints.addShoes, data);

    return response;
}

// export async function getDetails() {
    
// }