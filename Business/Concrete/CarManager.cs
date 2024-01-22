using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Car;
using Business.Responses.Car;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;
    private readonly CarBusinessRules _carBusinessRules;
    private readonly IMapper _mapper;

    private ModelManager _modelManager = new ModelManager();


    public CarManager(ICarDal carDal, CarBusinessRules carBusinessRules, IMapper mapper)
    {
        _carDal = carDal; //new InMemoryCarDal(); // Ba�ka katmanlar�n class'lar� new'lenmez. Bu y�zden dependency injection kullan�yoruz.
        _carBusinessRules = carBusinessRules;
        _mapper = mapper;
    }

    public AddCarResponse Add(AddCarRequest request)
    {
        // �� Kurallar�
        //_carBusinessRules.CheckIfCarNameNotExists(request.Name);
        Model model = _modelManager.FindByID(request.BrandId);

        // Validation
        // Yetki kontrol�
        // Cache
        // Transaction
        //Car carToAdd = new(request.Name)
        Car carToAdd = _mapper.Map<Car>(request); // Mapping
        carToAdd.Model = model;


        _carDal.Add(carToAdd);

        AddCarResponse response = _mapper.Map<AddCarResponse>(carToAdd);
        return response;
    }

    public GetCarListResponse GetList(GetCarListRequest request)
    {
        // �� Kurallar�
        // Validation
        // Yetki kontrol�
        // Cache
        // Transaction

        IList<Car> carList = _carDal.GetList();

        // carList.Items diye bir alan yok, bu y�zden mapping konfigurasyonu yapmam�z gerekiyor.

        // Car -> CarListItemDto
        // IList<Car> -> GetCarListResponse

        GetCarListResponse response = _mapper.Map<GetCarListResponse>(carList); // Mapping
        return response;
    }
}