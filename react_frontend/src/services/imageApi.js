import axios from 'axios';
export async function imageApi(file) {
    const formData = new FormData();
    formData.append('image', file);
    const response = await axios.post('http://localhost:5001/api/plantdb/diagnose', formData, {
        headers: {
            'Content-Type': 'multipart/form-data'
        }
    });
    return response.data;
}
export default imageApi;
