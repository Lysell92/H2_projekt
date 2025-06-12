import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { Link } from 'react-router-dom';
const Navbar = () => {
    return (_jsx("nav", { className: "navbar navbar-expand-lg navbar-dark plant-green fixed-top", children: _jsxs("div", { className: "container-fluid", children: [_jsx(Link, { className: "navbar-brand", to: "/", children: "Home" }), _jsx("button", { className: "navbar-toggler", type: "button", "data-bs-toggle": "collapse", "data-bs-target": "#navbarNav", children: _jsx("span", { className: "navbar-toggler-icon" }) }), _jsx("div", { className: "collapse navbar-collapse", id: "navbarNav", children: _jsxs("ul", { className: "navbar-nav ms-auto", children: [_jsx("li", { className: "nav-item", children: _jsx(Link, { className: "nav-link", to: "/Upload", children: "Plant Diagnosis" }) }), _jsx("li", { className: "nav-item", children: _jsx(Link, { className: "nav-link", to: "/About", children: "Model Information" }) })] }) })] }) }));
};
export default Navbar;
