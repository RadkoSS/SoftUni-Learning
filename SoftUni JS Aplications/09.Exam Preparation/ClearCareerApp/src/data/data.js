import * as api from './api.js'

const endPoints = {
    getAllShoes: 'data/shoes?sortBy=_createdOn%20desc',
    addShoes: 'data/shoes',
    getDetailsForOne: 'data/shoes/',
    searchByBrand: 'data/shoes?where=brand%20LIKE%20%22'
}

export async function allShoesData() {
    const response = await api.get(endPoints.getAllShoes);

    return response;
}

export async function addShoes(data) {
    const response = await api.post(endPoints.addShoes, data);

    return response;
}

export async function getDetailsById(id) {
    const response = await api.get(endPoints.getDetailsForOne + id);

    return response;
}

export async function deleteShoesById(id) {
    const response = await api.delete(endPoints.getDetailsForOne + id);

    return response;
}

export async function editShoesById(id, data) {
    const response = await api.put(endPoints.getDetailsForOne + id, data);

    return response;
}

export async function searchByBrand(query) {
    const response = await api.get(endPoints.searchByBrand + encodeURI(query) + '%22');

    return response;
}