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
        <h1 className="fs-3">Welcome to my image-recognition app</h1>
    );
}

export default Home;