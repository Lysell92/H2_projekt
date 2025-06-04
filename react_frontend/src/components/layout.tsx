import React from 'react';
import Navbar from './navbar';

const Layout: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    return (
        <>
            <Navbar />
            <main className="p-4">
                {children}
            </main>
        </>
    )
}

export default Layout;