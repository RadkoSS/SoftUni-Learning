import * as api from './api.js';

const endPoints = {
    'getAllIdeas': 'data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc',
    'createIdea': 'data/ideas'
}

export async function getAllIdeas(){
    return await api.get(endPoints.getAllIdeas);
}

export async function createIdea(data) {
    return await api.post(endPoints.createIdea, data);
}

export async function getIdeaDetails(id) {
    return await api.get(`${endPoints.createIdea}/${id}`);
}

export async function deleteIdea(id) {
    return await api.delete(`${endPoints.createIdea}/${id}`);
}