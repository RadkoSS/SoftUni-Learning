import * as api from './api.js';

const endPoints = {
    'getAllIdeas': 'data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc'
}

export function getAllIdeas(){
    return api.get(endPoints.getAllIdeas);
}