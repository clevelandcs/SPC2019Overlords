def main():
    number_of_cars = int(input())
    if number_of_cars >= 1 and number_of_cars <= 2 ** 64:
        cars = list(range(1, number_of_cars + 1))
        occupied_cars = list(range(1, number_of_cars + 1))
        current_car = number_of_cars
        for _ in range(0, 5):
            #Car that gets a pass
            current_car += 1
            if current_car > number_of_cars:
                current_car = 1
            if not current_car in occupied_cars:
                while not current_car in occupied_cars:
                    current_car += 1
                    if current_car > number_of_cars:
                        current_car = 1
            
            current_car += 1
            if current_car > number_of_cars:
                current_car = 1
            #Car that is unloaded
            if not current_car in occupied_cars:
                while not current_car in occupied_cars:
                    current_car += 1
                    if current_car > number_of_cars:
                        current_car = 1
            
            occupied_cars.remove(current_car)

        print(occupied_cars[len(occupied_cars) - 1])    

main()