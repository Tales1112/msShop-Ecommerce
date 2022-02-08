﻿using mShop.Core.Messages.Integration;
using System;
using System.Collections.Generic;

namespace mShop.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        private List<Event> _notificacoes;
        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        public void AdicionarEvento(Event evento)
        {
            _notificacoes = _notificacoes ?? new List<Event>();
            _notificacoes.Add(evento);
        }
        public void RemoverEvento(Event eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }
        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }
        public override bool Equals(object obj)
        {
            var CompareTo = obj as Entity;
            if (ReferenceEquals(this, CompareTo)) return true;
            if (ReferenceEquals(null, CompareTo)) return false;

            return Id.Equals(CompareTo.Id);
        }
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}