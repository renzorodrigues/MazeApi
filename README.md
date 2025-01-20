# Maze Pathfinding API

## Description
This API allows users to submit mazes, find paths through them due to a specific algorithm, and retrieve stored maze information.

## API Endpoints

### Submit a new maze
**POST /api/maze/submit**
```json
{
  "maze": "S____\n_XG__\n_____"
}
```
**Response:**
```json
{
  "maze": "S____\n_XG__\n_____",
  "solution": "S....\n.XG__\n_____"
}
```

### Get all submitted mazes
**GET /api/maze/mazes**
**Response:**
```json
[
  {
    "maze": "S____\n_XG__\n_____",
    "solution": "S....\n.XG__\n_____"
  }
]
```

## API Testing
The API provides an interactive **Swagger UI**. Access it at:
```
http://localhost:5000/swagger
```