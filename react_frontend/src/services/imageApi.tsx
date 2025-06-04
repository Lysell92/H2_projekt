import axios from 'axios';

export async function imageApi(file: File): Promise<string>  {


        /*const apiUrl = import.meta.env.VITE_URL_API;
        console.log("Calling API:", `${apiUrl}/api/plantdb/diagnose`);*/
    try {
        const formData = new FormData(); 
        formData.append('image', file)

        const response = await axios.post('http://localhost:5001/api/plantdb/diagnose',
                { headers: { 'Content-Type': 'multipart/form-data' },
            });
        return response.data.prediction;
        
        }
        catch (error)
        {
            console.error(error);
            return("Error occured uploading or diagnosing.");
        }
};

export default imageApi;
