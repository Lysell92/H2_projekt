import React, { useEffect } from 'react';
function Home() {

    useEffect(() => {
        document.body.classList.add('background-home');

        return () => {
            document.body.classList.remove('background-home');
        };
    },
        []);

    return (
        <h3 className="text-center fw-semibold mb-4 text-dark">Welcome to my image-recognition app</h3>
    );
}

export default Home;