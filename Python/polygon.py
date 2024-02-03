from typing import Iterable


class Point:
    def __init__(self, x: float, y: float) -> None:
        self.coords = (x, y)

    @property
    def x(self):
        return self.coords[0]

    @property
    def y(self):
        return self.coords[1]


class Edge:
    def __init__(self, start: Point, end: Point) -> None:
        self.__orientation = 0
        self.start = start
        self.end = end

        if start.y > end.y:
            self.__orientation = -1
        elif end.y > start.y:
            self.__orientation = 1

    @property
    def orientation(self):
        return self.__orientation

    def between_y_coords(self, y: float) -> bool:
        return (self.start.y < y and y < self.end.y) or (
            self.end.y < y and y < self.start.y
        )

    def horizontally_behind(self, x: float) -> bool:
        return x < min(self.start.x, self.end.x)


class Polygon2D:
    def __init__(self, *points: tuple[Iterable[float]]) -> None:
        if len(points) < 3:
            raise Exception("O polígono deve ter no mínimo 3 vértices.")
        
        self.vertices = [Point(*vertice) for vertice in points]
        self.edges = [
            Edge(vertice, self.vertices[(index + 1) % len(points)])
            for index, vertice in enumerate(self.vertices)
        ]

    def check_point_collide(self, point: Point) -> bool:
        laps = 0.0
        for edge in self.edges:
            if edge.horizontally_behind(point.x) and edge.between_y_coords(point.y):
                laps += edge.orientation
        return laps != 0
