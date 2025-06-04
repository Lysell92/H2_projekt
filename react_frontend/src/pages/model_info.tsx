import React, { useEffect } from 'react';
function About() {

    useEffect(() => {
        document.body.classList.add('background-about');

        return () => {
            document.body.classList.remove('background-about');
        };
    },
        []);

    return (
        <div className="container">
            <div id="model_accuracy" className="carousel slide" data-bs-ride="carousel">
                <div className="carousel-indicators">
                    <button type="button" data-bs-target="#model_accuracy" data-bs-slide-to="0" className="active" aria-current="true" aria-label="Slide 1"></button>
                    <button type="button" data-bs-target="#model_accuracy" data-bs-slide-to="1" aria-label="Slide 2"></button>
                </div>

                <div className="carousel-inner">
                    <div className="carousel-item active">
                        <img src="/val_accuracy.png" className="d-block w-50 mx-auto" alt="val_accuracy" />
                    </div>
                    <div className="carousel-item">
                        <img src="/val_loss.png" className="d-block w-30 mx-auto" alt="val_loss" />
                    </div>
                </div>

                <button className="carousel-control-prev" type="button" data-bs-target="#fili" data-bs-slide="prev">
                    <span className="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span className="visually-hidden">Previous</span>
                </button>
                <button className="carousel-control-next" type="button" data-bs-target="#fili" data-bs-slide="next">
                    <span className="carousel-control-next-icon" aria-hidden="true"></span>
                    <span className="visually-hidden">Next</span>
                </button>
            </div>

            <div className="container-fluid mt-2">
                <h3 className="text-center">To grafer som viser, hvordan min model blev trænet. Igennem 49 epoker kan man se, hvordan resultaterne forbedres og hvordan modellen tilpassede sig datasettet.</h3>
            </div>
        </div>
    );
};

export default About;