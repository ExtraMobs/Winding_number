class Point{
    coords = []
    
    get x(){
        return this.coords[0]
    }
    get y(){
        return this.coords[1]
    }

    constructor(x, y){
        this.coords = [x, y]
    }
}

class Edge{
    start
    end
    #orientation = 0
    
    get orientation(){
        return this.#orientation
    }
    
    constructor(start, end){
        this.start = start 
        this.end = end 

        if (start.y > end.y){
            this.#orientation = -1
        } else
        if (end.y > start.y){
            this.#orientation = 1
        }
    }

    betweenYCoords(y){
        return (
            (this.start.y < y && y < this.end.y) ||
            (this.end.y < y && y < this.start.y)
        )
    }

    horizontallyBehind(x){
        return (
            x < Math.min(this.start.x, this.end.x)
        )
    }
}

class Polygon2D{
    vertices = []
    edges = []
    constructor(points){
        if (points.length < 3){
            throw new Error("O polígono deve ter no mínimo 3 vértices.")
        }
        points.forEach(point => {
            this.vertices.push(new Point(point[0], point[1]))
        });
        for (let i = 0; i < points.length; i++){
            this.edges.push(new Edge(this.vertices[i], this.vertices[(i+1)%this.vertices.length]))
        }
    }

    checkPointCollide(point){
        let laps = 0

        this.edges.forEach(edge => {
            if (edge.horizontallyBehind(point.x) && edge.betweenYCoords(point.y)){
                laps += edge.orientation
            }
        })
        return laps != 0
    }
}

polygon = new Polygon2D(
    [
        // Defina as vértices do seu polígono, elas têm que
        // ser declarados em sequência, imaginando como se 
        // fosse um desenho no papel sem retirar o lápis até
        // terminar de desenhar o polígono.

        // [20, 20], [80, 20], [80, 20], [20, 80]
    ]
)

console.log(
    polygon.checkPointCollide(new Point(
        // Defina o ponto para checar colisão com o mesmo.
        
        //21, 19
    ))
)