import { BrowserRouter } from 'react-router-dom';
import './App.css';
import ListPage from './components/listPage';
import Login from './components/login';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'
import { history } from './history';
import { Navigate } from 'react-router'
import isAdminOrUser from './shared/token'

function App() {
  return (
    <Router history={history}>

      <div className="App">
        <header className="App-header">
          <Routes>
            <Route exact path="/" element={<Login />} />
            {isAdminOrUser ?
              <Route exact path="/list" element={<ListPage />} />
              : <Navigate replace to="/" />}
          </Routes>
        </header>
      </div>
    </Router>
  );
}

export default App;
