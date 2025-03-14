// Gestion du localStorage/sessionStorage
window.storage = {
    save: function(key, data) {
        const encrypted = btoa(JSON.stringify(data)); // Sérialisation et encodage
        localStorage.setItem(key, encrypted); // Sauvegarde dans localStorage
    },
    load: function(key) {
        const data = localStorage.getItem(key); // Chargement depuis localStorage
        try {
            return data ? JSON.parse(atob(data)) : null; // Désérialisation et décodage
        } catch {
            return null; // Retourne null en cas d'erreur
        }
    }
}// Storage.js

// Fonction pour sauvegarder des données dans le localStorage
function saveToLocalStorage(key, value) {
    localStorage.setItem(key, JSON.stringify(value)); // Sérialise et sauvegarde la valeur
}

// Fonction pour récupérer des données du localStorage
function getFromLocalStorage(key) {
    const value = localStorage.getItem(key); // Récupère la valeur
    return value ? JSON.parse(value) : null; // Désérialise et retourne la valeur ou null
}

// Fonction pour supprimer des données du localStorage
function removeFromLocalStorage(key) {
    localStorage.removeItem(key); // Supprime la valeur associée à la clé
};