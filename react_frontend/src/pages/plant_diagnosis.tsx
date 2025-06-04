import React, { useState, useEffect } from 'react';
import { imageApi } from '../services/imageApi';

function Upload() {
    const [file, setFile] = useState<File | null>(null);
    const [result, setResult] = useState("");

    const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.files) {
            setFile(e.target.files[0]);
        }
    };

    const handleUpload = async () => {
        if (!file) return;
        try {
            const prediction = await imageApi(file);
            setResult(prediction);
        } catch (err) {
            console.error(err);
            setResult("Error occurred during diagnosis.");
        }
    };

    useEffect(() => {
        document.body.classList.add('background-pd');

        return () => {
        document.body.classList.remove('background-pd');
            };
        },
        []);

    return (
        <div className="background-pd">
            <div className="d-flex justify-content-center align-items-start" style={{ minHeight: '100vh', paddingTop: '80px' }}>
                <div className="upload-container" style={{ maxWidth: '400px', width: '100%' }}>
                    <h1 className="h2 fw-semibold mb-4 text-dark">Plant Diagnosis</h1>

                    <input type="file" onChange={handleFileChange} className="mb-3 form-control" />
                    <button onClick={handleUpload} className="btn btn-success mb-3 w-100">Upload</button>
                    {result && (
                        <div className="mt-4 p-3 bg-light rounded w-100">
                            <h2 className="fw-bold h5">Prediction:</h2>
                            <p>{result}</p>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
}

export default Upload;