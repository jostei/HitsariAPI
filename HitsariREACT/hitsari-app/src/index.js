import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import ApiConnect from './ApiConnect';

ReactDOM.render(
  <React.StrictMode>
    <App />
    {/* yhteys localhostiin ei toimi oletuksena !*/}
    <ApiConnect url="https://localhost:44317/api/workers/tolist" />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
