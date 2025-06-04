import React from 'react';
import { Link } from 'react-router-dom';



const Navbar: React.FC = () => {
    return (
        <nav className="navbar navbar-expand-lg navbar-dark plant-green fixed-top">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/">Home</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ms-auto">
                        <li className="nav-item">
                            <Link className="nav-link" to="/Upload">Plant Diagnosis</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/About">Model Information</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;