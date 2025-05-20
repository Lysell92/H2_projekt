import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react-swc';
/*import fs from 'fs';
import path from 'path';*/

export default defineConfig({
    plugins: [react()],
    server: {
        proxy: {
            '/api': {
                target: 'http://localhost:5001', // your ASP.NET Core backend
                changeOrigin: true,
                secure: false,
            },
        },
    },
});
