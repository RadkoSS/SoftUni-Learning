import * as api from './api.js'

const endPoints = {
    getAllGames: 'data/games?sortBy=_createdOn%20desc',
    getDetailsForOne: 'data/games/',
    getMostRecentGames: 'data/games?sortBy=_createdOn%20desc&distinct=category',
    createGame: 'data/games',
    updateApplicationsCount: 'data/applications',
    getAllComments: 'data/comments?where=gameId%3D%22',
    postComment: 'data/comments'
}

export async function allGamesData() {
    const response = await api.get(endPoints.getAllGames);

    return response;
}

export async function mostRecentGames() {
    const response = await api.get(endPoints.getMostRecentGames);

    return response;
}

export async function addGame(data) {
    const response = await api.post(endPoints.createGame, data);

    return response;
}

export async function getDetailsById(id) {
    const response = await api.get(endPoints.getDetailsForOne + id);

    return response;
}

export async function deleteGameById(id) {
    const response = await api.delete(endPoints.getDetailsForOne + id);

    return response;
}

export async function editGameById(id, data) {
    const response = await api.put(endPoints.getDetailsForOne + id, data);

    return response;
}

export async function getAllComments(gameId) {
    const response = await api.get(endPoints.getAllComments + encodeURI(gameId) + '%22');

    return response;
}

export async function postComment(gameId, comment) {
    const response = await api.post(endPoints.postComment, { gameId, comment });

    return response;
}