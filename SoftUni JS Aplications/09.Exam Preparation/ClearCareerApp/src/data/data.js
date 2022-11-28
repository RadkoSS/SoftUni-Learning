import * as api from './api.js'

const endPoints = {
    getAllOffers: 'data/offers?sortBy=_createdOn%20desc',
    getDetailsForOne: 'data/offers/',
    createOffer: 'data/offers',
    updateApplicationsCount: 'data/applications',
    getCountOfApplications: 'data/applications?where=offerId%3D%22',
    ownershipCheck: 'data/applications?where=offerId%3D%22'
}

export async function allOffersData() {
    const response = await api.get(endPoints.getAllOffers);

    return response;
}

export async function addOffer(data) {
    const response = await api.post(endPoints.createOffer, data);

    return response;
}

export async function getDetailsById(id) {
    const response = await api.get(endPoints.getDetailsForOne + id);

    return response;
}

export async function deleteOfferById(id) {
    const response = await api.delete(endPoints.getDetailsForOne + id);

    return response;
}

export async function editOfferById(id, data) {
    const response = await api.put(endPoints.getDetailsForOne + id, data);

    return response;
}

export async function applicationsCount(id) {
    const response = await api.get(endPoints.getCountOfApplications + encodeURI(id) + '%22&distinct=_ownerId&count');

    return response;
}

export async function updateApplicationsCount(offerId) {
    const response = await api.post(endPoints.updateApplicationsCount, { offerId });

    return response;
}

export async function checkIfUserIsOwner(offerId, userId) {
    const response = await api.get(endPoints.ownershipCheck + encodeURI(offerId) + '%22%20and%20_ownerId%3D%22' + encodeURI(userId) + '%22&count');

    return response;
}