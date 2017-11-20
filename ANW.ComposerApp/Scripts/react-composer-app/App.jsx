import React from 'react';
import ReactDOM from 'react-dom';

class TagLine extends React.Component {
  render() {
      return <p>Find music to be passionate about</p>
  }
}

ReactDOM.render(<TagLine/>, document.getElementById('tag-line'));