import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/navbar';
import Home from './pages/home';
import About from './pages/model_info'
import Upload from './pages/plant_diagnosis'
import './App.css'

function App() {
    return (
        <Router>
        <Navbar />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/upload" element={<Upload />} />
                <Route path="/About" element={<About />} />
            </Routes>
        </Router>
    );
}

export default App
