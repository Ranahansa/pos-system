const API_BASE_URL = 'https://api.example.com';

const endpoints = {
    getProducts: `${API_BASE_URL}/products`,
    getProductById: (id) => `${API_BASE_URL}/products/${id}`,
    createProduct: `${API_BASE_URL}/products`,
    updateProduct: (id) => `${API_BASE_URL}/products/${id}`,
    deleteProduct: (id) => `${API_BASE_URL}/products/${id}`
};

export default endpoints;