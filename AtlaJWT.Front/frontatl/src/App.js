import { BrowserRouter } from 'react-router-dom';
import './App.css';
import Login from './components/login';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'
import { history } from './history';
import PageUser from './components/pageUser';
import isAdminOrUser from './shared/token'
import ListPage from './components/listPage';

function App() {
  return (
    <Router history={history}>

      <div className="App">
        <header className="App-header">
          <Routes>
            <Route exact path="/" element={<Login />} />
            {
              isAdminOrUser ?
                <Route exact path="/list" element={<ListPage />} />
                : <Route exact path="/user" element={<PageUser />} />
            }
          </Routes>
        </header>
      </div>
    </Router>
  );
}

export default App;
