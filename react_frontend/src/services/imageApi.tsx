import axios from 'axios';


type PlantDetails = {
    stringlabel: string;
    description: string;
    assessment: string;
};

type ApiResult = {
    prediction: string;
    details: PlantDetails;
};

export async function imageApi(file: File): Promise<ApiResult> {

    const formData = new FormData();
    formData.append('image', file)

    const response = await axios.post('https://plantweb.local/api/plantdb/diagnose',
        formData,
        {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        }
    );
    return response.data;
}

export default imageApi;
