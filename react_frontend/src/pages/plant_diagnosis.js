import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { useState, useEffect } from 'react';
import { imageApi } from '../services/imageApi';
function Upload() {
    const [file, setFile] = useState(null);
    const [result, setResult] = useState(null);
    const handleFileChange = (e) => {
        if (e.target.files) {
            setFile(e.target.files[0]);
        }
    };
    const [error, setError] = useState(null);
    const handleUpload = async () => {
        if (!file)
            return;
        setError(null);
        try {
            const result = await imageApi(file);
            setResult(result);
        }
        catch (err) {
            console.error(err);
            setResult(null);
            setError("Error occurred during diagnosis.");
        }
    };
    useEffect(() => {
        document.body.classList.add('background-pd');
        return () => {
            document.body.classList.remove('background-pd');
        };
    }, []);
    return (_jsx("div", { className: "background-pd", children: _jsx("div", { className: "d-flex justify-content-center align-items-start", style: { minHeight: '100vh', paddingTop: '80px' }, children: _jsxs("div", { className: "upload-container", style: { maxWidth: '400px', width: '100%' }, children: [_jsx("h1", { className: "h2 fw-semibold mb-4 text-dark", children: "Plant Diagnosis" }), _jsx("input", { type: "file", onChange: handleFileChange, className: "mb-3 form-control" }), _jsx("button", { onClick: handleUpload, className: "btn btn-success mb-3 w-100", children: "Upload" }), result && (_jsxs("div", { className: "mt-4 p-3 bg-light rounded w-100", children: [_jsx("h2", { className: "fw-bold h5", children: "Prediction:" }), _jsx("p", { children: result.prediction }), _jsx("h2", { className: "fw-bold h5", children: "Description:" }), _jsx("p", { children: result.details.description }), _jsx("h2", { className: "fw-bold h5", children: "Assessment:" }), _jsx("p", { children: result.details.assessment })] }))] }) }) }));
}
export default Upload;
