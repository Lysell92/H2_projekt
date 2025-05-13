import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react-swc';
import fs from 'fs';
import path from 'path';

export default defineConfig({
    plugins: [react()],
    server: {
        https: {
            key: fs.readFileSync(path.resolve(__dirname, 'certs/localhost-key.pem')),
            cert: fs.readFileSync(path.resolve(__dirname, 'certs/localhost.pem')),
    },
    proxy: {
            '/api': {
                target: 'https://localhost:5001', // your ASP.NET Core backend
                changeOrigin: true,
                secure: false, // because localhost has self-signed SSL cert
            },
        },
    },
})
