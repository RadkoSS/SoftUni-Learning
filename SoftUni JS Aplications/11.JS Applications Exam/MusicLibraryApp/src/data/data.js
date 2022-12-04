import * as api from './api.js'

const endPoints = {
    getAllAlbums: 'data/albums?sortBy=_createdOn%20desc',
    getDetailsForOne: 'data/albums/',
    createAlbum: 'data/albums',
    likeAlbum: 'data/likes',
    getCountOfLikes: (albumId) => `data/likes?where=albumId%3D%22${albumId}%22&distinct=_ownerId&count`,
    checkLikedState: (albumId, userId) => `data/likes?where=albumId%3D%22${albumId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

export async function allAlbumsData() {
    const response = await api.get(endPoints.getAllAlbums);

    return response;
}

export async function addAlbum(data) {
    const response = await api.post(endPoints.createAlbum, data);

    return response;
}

export async function getDetailsById(id) {
    const response = await api.get(endPoints.getDetailsForOne + id);

    return response;
}

export async function deleteAlbumById(id) {
    const response = await api.delete(endPoints.getDetailsForOne + id);

    return response;
}

export async function editAlbumById(id, data) {
    const response = await api.put(endPoints.getDetailsForOne + id, data);

    return response;
}

export async function getLikesCount(albumId) {
    const response = await api.get(endPoints.getCountOfLikes(encodeURI(albumId)));

    return response;
}

export async function likeAlbum(albumId) {
    const response = await api.post(endPoints.likeAlbum, { albumId });

    return response;
}

export async function checkLikedState(albumId, userId) {
    const response = await api.get(endPoints.checkLikedState(encodeURI(albumId), encodeURI(userId)));

    return response;
}