import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { useEffect } from 'react';
function About() {
    useEffect(() => {
        document.body.classList.add('background-about');
        return () => {
            document.body.classList.remove('background-about');
        };
    }, []);
    return (_jsxs("div", { className: "container", children: [_jsxs("div", { id: "model_accuracy", className: "carousel slide", "data-bs-ride": "carousel", children: [_jsxs("div", { className: "carousel-indicators", children: [_jsx("button", { type: "button", "data-bs-target": "#model_accuracy", "data-bs-slide-to": "0", className: "active", "aria-current": "true", "aria-label": "Slide 1" }), _jsx("button", { type: "button", "data-bs-target": "#model_accuracy", "data-bs-slide-to": "1", "aria-label": "Slide 2" })] }), _jsxs("div", { className: "carousel-inner", children: [_jsx("div", { className: "carousel-item active", children: _jsx("img", { src: "/val_accuracy.png", className: "d-block w-50 mx-auto", alt: "val_accuracy" }) }), _jsx("div", { className: "carousel-item", children: _jsx("img", { src: "/val_loss.png", className: "d-block w-30 mx-auto", alt: "val_loss" }) })] }), _jsxs("button", { className: "carousel-control-prev", type: "button", "data-bs-target": "#model_accuracy", "data-bs-slide": "prev", children: [_jsx("span", { className: "carousel-control-prev-icon", "aria-hidden": "true" }), _jsx("span", { className: "visually-hidden", children: "Previous" })] }), _jsxs("button", { className: "carousel-control-next", type: "button", "data-bs-target": "#model_accuracy", "data-bs-slide": "next", children: [_jsx("span", { className: "carousel-control-next-icon", "aria-hidden": "true" }), _jsx("span", { className: "visually-hidden", children: "Next" })] })] }), _jsx("div", { className: "container-fluid mt-2", children: _jsx("h3", { className: "text-center fw-semibold mb-4 text-dark", children: "To grafer som viser, hvordan min model blev tr\u00E6net. Igennem 49 epoker kan man se, hvordan resultaterne forbedres og hvordan modellen tilpassede sig datasettet." }) })] }));
}
;
export default About;
