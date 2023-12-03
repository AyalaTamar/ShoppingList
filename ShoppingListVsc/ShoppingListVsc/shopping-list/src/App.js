import { BrowserRouter, Route, Routes } from 'react-router-dom'
import React, { useState } from "react";
import './App.css';
import Home from './Home';

function App() {
  return (
    <div >
      <BrowserRouter>
        <Routes>
        <Route path="/" element={<Home />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
