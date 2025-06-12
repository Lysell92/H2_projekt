import { jsx as _jsx } from "react/jsx-runtime";
import { useEffect } from 'react';
function Home() {
    useEffect(() => {
        document.body.classList.add('background-home');
        return () => {
            document.body.classList.remove('background-home');
        };
    }, []);
    return (_jsx("h3", { className: "text-center fw-semibold mb-4 text-dark", children: "Welcome to my image-recognition app" }));
}
export default Home;
