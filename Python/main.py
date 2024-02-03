from polygon import Point, Polygon2D
import os


def main():
    os.system("cls")
    print(
        "    Olá, esse programa irá dizer se o seu ponto, está dentro do polígono estabelecido."
    )
    print("    Para isso, começaremos digitando o X e o Y dos vértices.")
    print(
        "    Deixando em branco qualquer um dos dois, terminará a inserção de vértices.\n"
    )

    points = []

    x: float
    y: float
    command: str
    while True:
        print(str(len(points) + 1) + ". ")
        command = input("    X ->")
        if command == "":
            break
        x = float(command.replace(" ", "").replace(",", "."))

        command = input("    Y ->")
        if command == "":
            break
        y = float(command.replace(" ", "").replace(",", "."))
        print()

        points.append((x, y))

    polygon = Polygon2D(*points)

    while True:
        print("\n\nInforme qual a posição do seu ponto.")
        command = input("    X ->")
        if command == "":
            break
        x = float(command.replace(" ", "").replace(",", "."))

        command = input("    Y ->")
        if command == "":
            break
        y = float(command.replace(" ", "").replace(",", "."))

        if polygon.check_point_collide(Point(x, y)):
            print("\n\nSeu ponto está DENTRO do polígono.")
        else:
            print("\n\nSeu ponto está FORA do polígono.")


if __name__ == "__main__":
    main()
