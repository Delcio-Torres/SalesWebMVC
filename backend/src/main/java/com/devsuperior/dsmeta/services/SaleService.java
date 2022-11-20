package com.devsuperior.dsmeta.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.GetMapping;

import com.devsuperior.dsmeta.entities.Sale;
import com.devsuperior.dsmeta.repositories.SaleRepository;


@Service
public class SaleService {
	
	@Autowired
	private SaleRepository repository;
	
	@GetMapping
	public List<Sale> findSales() {
		return repository.findAll();
	}

}
