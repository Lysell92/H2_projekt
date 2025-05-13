import { useState } from 'react';
import axios from 'axios';

function ImageUpload() {
    const [file, setFile] = useState(null);
    const [result, setResult] = useState("");

    const handleFileChange = (e) => {
        setFile(e.target.files[0]);
    };

    const handleUpload = async () => {
        if (!file) return;

        const formData = new FormData();
        formData.append('image', file);

        try {
            const response = await axios.post('/api/diagnose', formData,
                { headers: { 'Content-Type': 'multipart/form-data' }
            });
        setResult(response.data.prediction)
    }   catch (error) {
        console.error(error);
        setResult("Error occured uploading or diagnosing.");
    }
};


    return (
        <div>
        <h2>Upload Plant Image </h2>
            <input type = "file" onChange = { handleFileChange } />
            <button onClick={ handleUpload }>Upload</button>

    {result && (
            <div>
                <h3>Prediction: </h3>
                <p> { result } </p>
                </div>
            )}
        </div>
    );
}

export default ImageUpload;